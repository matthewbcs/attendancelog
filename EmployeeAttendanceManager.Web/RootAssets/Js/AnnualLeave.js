
var app = angular.module('app', []);
 
app.controller('AnnualLeaveViewCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.newEmployee = {};

    // to and then from  - used to put controller data into scope so can use in angular 
    $.extend($scope, window.controllerData.AnnualLeaveViewModel);

    $scope.addAnnualLeave = function () {

        var postData = {};
        postData.employeeId = $scope.addAnnualLeave.SelectedEmployee;
        postData.FromDate = $scope.addAnnualLeave.FromDate;
        postData.ToDate = $scope.addAnnualLeave.ToDate;
        $http.post('/AnnualLeave/AddAnnualLeave', postData).then(
            function (response) {
                
                alert(response.data.Message);
                if (response.data.WasSucess === true) {
                    window.location.reload();
                }
                
            });
    };
}]);