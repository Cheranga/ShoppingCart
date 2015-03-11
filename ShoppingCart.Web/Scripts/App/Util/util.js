define("App/Util/util", [], function () {

    var self = this;
    self.objectState = {
        Unchanged: 0,
        Added: 1,
        Updated: 2,
        Deleted: 3
    };

   

    return {
        ObjectState:self.objectState
    };
});