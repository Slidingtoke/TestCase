$(function () {
    function User(userJsonObject) {

        var self = this;

        self.ID = ko.observable('');
        self.Name = ko.observable('');
        self.Email = ko.observable('');
        self.TodoEntries = ko.observableArray([]);

        self.updateValuesFromJSON = function (userJsonObject) {
            self.ID(userJsonObject.ID);
            self.Name(userJsonObject.Name);
            self.Email(userJsonObject.Email);
            $.each(userJsonObject.TodoEntries, function (idx, obj) {
                self.TodoEntries.push(new TodoEntry(obj));
            });

        };

        self.updateValuesFromJSON(userJsonObject);
    }
    function TodoEntry(todoEntryJsonObject) {

        var self = this;

        self.ID = ko.observable('');
        self.Title = ko.observable('');
        self.Description = ko.observable('');
        self.Type = ko.observable('');

        self.updateValuesFromJSON = function (todoEntryJsonObject) {
            self.ID(todoEntryJsonObject.ID);
            self.Title(todoEntryJsonObject.Title);
            self.Description(todoEntryJsonObject.Description);
            self.Type(todoEntryJsonObject.Type);

        };

        self.updateValuesFromJSON(todoEntryJsonObject);
    }

    function UserViewModel() {
        var self = this;

        self.userList = ko.observableArray();
        self.sortColumn = ko.observable("ID");
        self.isSortAscending = ko.observable(true);
        self.selectedUser = ko.observable('');

        self.populateUserList = function () {
            self.showLoader();
            $.ajax({
                type: "get",
                url: "/Rest/users",
                data: {
                },
                contentType: 'application/json; charset=utf-8',
                success: function (jsonData) {
                    self.userList.removeAll();

                    $.each(jsonData, function (idx, obj) {
                        self.userList.push(new User(obj));
                    });
                    self.hideLoader();
                    $('#user-table').show();
                    $('#user-details').hide();
                }
            });
        }

        self.addNewUser = function (name, email) {
            $("#newUserForm").validate()
            if ($("#newUserForm").valid()) {
                $.ajax({
                    type: "post",
                    url: "/Rest/AddUser",
                    data: JSON.stringify({
                        Name: name,
                        Email: email
                    }),
                    contentType: 'application/json; charset=utf-8',
                    success: function () {
                        $("#newUserModal").modal("hide");
                        self.populateUserList();
                    },
                    error: function () {
                        alert('Could not add user!');
                    }
                });
            }
        }
        self.addNewTodoToSelectedUser = function (title, description, type) {
            $("#newTodoEntryForm").validate()
            if ($("#newTodoEntryForm").valid()) {
                var newTodoObject = new Object();
                newTodoObject.Title = title;
                newTodoObject.Description = description;
                newTodoObject.Type = type;
                self.selectedUser().TodoEntries.push(newTodoObject);

                $.ajax({
                    type: "post",
                    url: "/Rest/UpdateUser",
                    data: ko.toJSON(self.selectedUser),
                    contentType: 'application/json; charset=utf-8',
                    success: function () {
                        $("#newTodoEntryModal").modal("hide");
                        self.populateUserList();
                    },
                    error: function () {
                        alert('Could not update user!');
                    }
                });
            }

        }

        self.sortFunction = function (isSortingTodoEntries) {
            if (self.sortColumn() === event.target.id)
                self.isSortAscending(!self.isSortAscending());
            else {
                self.sortColumn(event.target.id);
                self.isSortAscending(true);
            }
            if (isSortingTodoEntries === true) {
                self.selectedUser().TodoEntries.sort(function (a, b) {
                    if (a[self.sortColumn()]() < b[self.sortColumn()]()) return !self.isSortAscending();
                    else return self.isSortAscending();
                });
            }
            else {
                self.userList.sort(function (a, b) {
                    if (a[self.sortColumn()]() < b[self.sortColumn()]()) return !self.isSortAscending();
                    else return self.isSortAscending();
                });

            
            }
        }

        self.selectUser = function (user) {
            self.selectedUser(user);
            self.showDetailsUser();
        }

        self.showLoader = function () {
            $("#loading").show();
        }
        self.hideLoader = function () {
            $("#loading").hide();
        }

        self.showDetailsUser = function () {
            $('#user-table').hide();
            $('#user-details').show();
        }
        self.hideDetailsUser = function () {
            $('#user-table').show();
            $('#user-details').hide();
        }

        self.populateUserList();

    }

    ko.applyBindings(new UserViewModel());
});

