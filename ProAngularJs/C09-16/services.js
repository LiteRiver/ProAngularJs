var now = new Date();
angular.module("ExampleApp.Services", [])    
    .service("Days", function (nowValue) {
        this.today = nowValue.getDay();
        this.tomorrow = (this.today + 1) % 7;
    });