define(['jquery', 'knockout'], function ($, ko) {
    function TodoEntryModel(todoEntryJsonObject) {

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
    return TodoEntryModel;
});