
var app = angular.module('app', ['ngMaterial', 'ngMessages']).config(function($mdDateLocaleProvider) {
           
    $mdDateLocaleProvider.parseDate = function(dateString) {
        var m = moment(dateString, 'M/D', true);
        return m.isValid() ? m.toDate() : new Date(NaN);
    };

       
         
    $mdDateLocaleProvider.isDateComplete = function(dateString) {
        dateString = dateString.trim();
        // Look for two chunks of content (either numbers or text) separated by delimiters.
        var re = /^(([a-zA-Z]{3,}|[0-9]{1,4})([ .,]+|[/-]))([a-zA-Z]{3,}|[0-9]{1,4})/;
        return re.test(dateString);
    };
});


 
app.controller('AddAttendanceLogCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.newEmployee = {};
  //  $scope.AnnualLeaveListing = [{}];

  

    // to and then from  - used to put controller data into scope so can use in angular 
    $.extend($scope, window.controllerData.AttendanceModel);

    $scope.AddAttendanceLog = function () {

        var postData = {};
        postData.attendanceLogs = $scope.AttendanceList;
      

        //if (postData.FromDate === null || postData.ToDate === null) {
        //    alert("from date or to date must have a value");
        //    return;
        //}
        //if (typeof postData.employeeId == 'undefined') {
        //    alert("Please select a employee");
        //    return;
        //}

        $http.post('/Attendance/CreateAttendanceLog', postData).then(
            function (response) {
                

                    $scope.ServerSuccess = response.data.WasSuccess;
                    $scope.ServerResponse = response.data.Message;
                    

            });
    };

    $scope.Settoday = function () {
        var now = new Date();
        for (var i = 0; i < $scope.AttendanceList.length; i++) {
            $scope.AttendanceList[i].DateAttended = now;
        }
       
    }; 
    $scope.AddEmployeeAttendance = function () {
        alert("THIS IS NOT IMPLEMENTED YET!!");

    };

    $scope.UpdateDate = function () {
      
        for (var i = 0; i < $scope.AttendanceList.length; i++) {
            $scope.AttendanceList[i].DateAttended = $scope.MainAttendDateToUse;
        }
       
    };
    $scope.SetPresent = function () {
        var now = new Date();
        for (var i = 0; i < $scope.AttendanceList.length; i++) {
            $scope.AttendanceList[i].SelectedStatus = $scope.StatusList[0];
        }
       
    };



    
}]);
