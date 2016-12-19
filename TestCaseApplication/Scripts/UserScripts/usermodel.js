define(['jquery', 'knockout', 'todoentrymodel'], function ($, ko, TodoEntryModel) {
    function UserModel(userJsonObject) {

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
                self.TodoEntries.push(new TodoEntryModel(obj));
            });

        };

        self.updateValuesFromJSON(userJsonObject);
    }
    return UserModel;
});