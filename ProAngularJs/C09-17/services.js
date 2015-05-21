angular.module("ExampleApp.Services", [])    
    .service("Days", function (nowValue) {
        this.today = nowValue.getDay();
        this.tomorrow = (this.today + 1) % 7;
    })
    .config(function () {
        console.log("Services module config: (no time)");
    })
    .run(function (StartTime) {
        console.log("Services module run: " + StartTime);
    });