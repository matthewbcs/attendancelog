
var app = angular.module('app', []);
 
app.controller('EmployeeCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.newEmployee = {};

    // to and then from  - used to put controller data into scope so can use in angular 
    $.extend($scope, window.controllerData.EmployeeMddel);

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
}]);