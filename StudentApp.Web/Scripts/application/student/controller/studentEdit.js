
(function (ng,_) {
    'use strict';

    ng.module('studentApp.student.controllers')
       .controller('StudentEditController', ['$route','$scope', '$location', 'StudentProvider', StudentEditController]);

    function StudentEditController($route, $scope, $location, Student) {

        var vm = this;
        vm.student = {};
        vm.submitForm = submitForm;
        vm.coursesList = [];
        vm.goToList = goToList;
        vm.errorMessage = [];

        load();

        /////////////////////////////////////////////////////////////

        function load() {
            vm.student = $route.current.locals.student.data;
            vm.courses = $route.current.locals.courses.data.list;
            vm.editCourses = vm.student.courseItems;
            if (vm.editCourses.length > 0) {
                _(vm.courses).map(function (item) {
                    var selectedItem = _(vm.editCourses).findWhere({ 'id': item.id });
                    if (selectedItem) {
                        item.selected = true;
                    } else {
                        item.selected = false;
                    }
                });
            }
        }

        function goToList() {
            $location.path('/students');
        }

        function submitForm() {
            vm.errorMessage = [];
            var selectItem = _(vm.courses).where({ 'selected': true });
            vm.student.coursesList = _(selectItem).pluck('id');

            Student.update(vm.student).then(function (response) {
                if (response.data.modelState) {
                    $.map(response.data.modelState, function (value, index) {
                        _(value).each(function(item) {
                            vm.errorMessage.push(item);
                        });
                        return [value];
                    });
                    alert('Update student failed. See the error message at top section.');
                } else {

                    alert('Student Successfully updated');
                    vm.goToList();
                }
            }, function (response) {
            });
        }

    }


})(angular,_);