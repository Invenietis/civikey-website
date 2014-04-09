app.controller('KeyboardsController', ["$scope", "$upload", "$timeout", function ($scope, $upload, $timeout) {
    $scope.newKeyboard = {
        name: "",
        description: "",
        author: "",
        email: ""
    }
    $scope.thumbnail = null;
    $scope.keyboardPicture = null;
    $scope.submitted = false;
    $scope.submitKeyboard = function () {
        console.log($scope.form.$valid);
        $scope.submitted = true;
        if (!$scope.form.$valid) return;

        $scope.upload = $upload.upload({
            url: 'addkeyboard',
            data: $scope.newKeyboard,
            file: $scope.keyboardPicture,
        }).progress(function (evt) {
            //console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
        }).success(function (data, status, headers, config) {
            // file is uploaded successfully
            console.log(data);
            $('#import').modal('hide');
            $scope.resetForm();
        });
        //.error(...)
        //.then(success, error, progress); 
        //.xhr(function(xhr){xhr.upload.addEventListener(...)})// access and attach any event listener to XMLHttpRequest.
    }
    $scope.resetForm = function () {
        $scope.newKeyboard = {
            name: "",
            description: "",
            author: "",
            email: ""
        }
        $scope.keyboardPicture = null;
        $scope.submitted = false;
        $scope.thumbnail = null;
    }
    $scope.onFileSelect = function ($files) {
        if ($files.length == 0) return;
        $scope.keyboardPicture = $files[0];

        if (window.FileReader && $scope.keyboardPicture.type.indexOf('image') > -1) {
            var fileReader = new FileReader();
            fileReader.readAsDataURL($scope.keyboardPicture);
            var loadFile = function (fileReader) {
                fileReader.onload = function (e) {
                    $timeout(function () {
                        $scope.$apply(function () {
                            $scope.thumbnail = e.target.result;
                        });
                        console.log($scope.tinyPicture);
                    });
                }
            }(fileReader);
        }
    };
}]);