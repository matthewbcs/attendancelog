
var app = angular.module('app', []);
 
app.controller('AnnualLeaveCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.newEmployee = {};
  //  $scope.AnnualLeaveListing = [{}];

    // to and then from  - used to put controller data into scope so can use in angular 
    $.extend($scope, window.controllerData.AnnualLeaveModel);

    $scope.addAnnualLeave = function () {

        var postData = {};
        postData.employeeId = $scope.addAnnualLeave.SelectedEmployee;
        postData.FromDate = $scope.addAnnualLeave.FromDate;
        postData.ToDate = $scope.addAnnualLeave.ToDate;

        if (postData.FromDate === null || postData.ToDate === null) {
            alert("from date or to date must have a value");
            return;
        }
        if (typeof postData.employeeId == 'undefined') {
            alert("Please select a employee");
            return;
        }

        $http.post('/AnnualLeave/AddAnnualLeave', postData).then(
            function (response) {
                

                    $scope.ServerSuccess = response.data.WasSuccess;
                    $scope.ServerResponse = response.data.Message;
                    

            });
    };

    $scope.CheckAvailability = function () {

        var postData = {};
        postData.FromDate = $scope.addAnnualLeave.FromDate;
        postData.ToDate = $scope.addAnnualLeave.ToDate;
        $http.post('/AnnualLeave/CheckAvailability', postData).then(
            function (response) {
                
                if (response.data.length > 0) {
                    var results = [];
                    for (var i = 0; i < response.data.length; i++) {
                        var annualLeave =
                        {
                            "EmployeeName": response.data[i].EmployeeName,
                            "AnnualLeaveDate": response.data[i].AnnualLeaveDateAsString,
                            "IsHalfDay": response.data[i].IsHalfDay,

                        };

                        results.push(annualLeave);

                    }
                    $scope.AnnualLeaveListing = results;
                    // $scope.AnnualLeaveListing = results;
                }
                if (response.data.length < 1) {
                    $scope.AvaliablityResponse = "The dates selected are available";
                }

                if (response.data.WasSucess === true) {
                    window.location.reload();
                }
                
            });
    };
}]);