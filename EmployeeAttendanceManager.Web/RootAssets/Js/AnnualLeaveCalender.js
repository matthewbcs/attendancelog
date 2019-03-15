
var app = angular.module('app', []);
 
app.controller('CalenderCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.newEmployee = {};

    // to and then from  - used to put controller data into scope so can use in angular 
    $.extend($scope, window.controllerData.CalenderModel);

    $scope.addEmployee = function () {

        var postData = {};
        postData.firstName = $scope.newEmployee.Firstname;
        postData.surName = $scope.newEmployee.Surname;
        $http.post('/Employee/AddNewEmployee', postData).then(
            function (response) {
                
                alert(response.data.Message);
                if (response.data.WasSucess === true) {
                    window.location.reload();
                }
                
            });
    };

    $(function() {

        // page is now ready, initialize the calendar...

        $('#calendar').fullCalendar({
            // put your options and callbacks here


            //events: [
            //    {

            //        title: 'Event Title1',
            //        start: '2019-02-13T13:13:55.008',
            //        end: '2019-02-13T13:14:55.008'
            //    }
            //]


            eventSources: [

                // your event source
                {
                    url: '/AnnualLeave/GetCalenderEvents',
                    type: 'POST',
                    data: {
                        
                    },
                    error: function() {
                        alert('there was an error while fetching events!');
                    },
                    color: 'yellow',   // a non-ajax option
                    textColor: 'black' // a non-ajax option
                }

                // any other sources...

            ]
        
        });;

    });
}]);