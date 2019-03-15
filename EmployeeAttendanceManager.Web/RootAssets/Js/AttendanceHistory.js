
var app = angular.module('app', []);
 
app.controller('AttendanceHistoryCtrl', ['$scope', '$http', function ($scope, $http) {

    

    // to and then from  - used to put controller data into scope so can use in angular 
    $.extend($scope, window.controllerData.HistoryModel);

    $scope.updateStatus = function (logId,status) {

     
        var postData = {};
        postData.logId = logId;
        postData.statusId = status.AttendanceStatusId;
        $http.post('/Attendance/UpdateAttendanceStatus', postData).then(
            function (response) {
                
                alert(response.data.Message);
                if (response.data.WasSucess === true) {
                    window.location.reload();
                }
                
            });
    };
}]);