

(function (ng, _) {
    'use strict';

    ng.module('studentApp.student.controllers').controller('StudentCreateController', StudentCreateController);
    StudentCreateController.$inject = ['$scope', '$route', '$location', 'StudentProvider'];

    function StudentCreateController($scope, $route, $location, StudentProvider) {

        var vm = this;
        vm.student = {};
        vm.courses = [];
        vm.coursesList = [];
        vm.selectCourse = selectCourse;
        vm.submitForm = submitForm;
        vm.goToList = goToList;
        vm.errorMessage = [];

        load();

        ////////////////////////////////////////////////////////////////

        function load() {
            vm.courses = $route.current.locals.courses.data.list;
        }

        function selectCourse() {
            var selectedFilters = _(vm.courses).filter(function (item) { return item.selected; });
            vm.coursesList = _.pluck(selectedFilters, 'id');
        }

        function submitForm() {
            vm.errorMessage = [];
            vm.student.coursesList = vm.coursesList;

            StudentProvider.create(vm.student).then(function (response) {
                if (response.data.modelState) {
                    $.map(response.data.modelState, function (value, index) {
                        _(value).each(function (item) {
                            vm.errorMessage.push(item);
                        });
                        return [value];
                    });
                    alert('Create student failed. See the error message at top section.');
                } else {
                    alert('Student Successfully created');
                    vm.goToList();
                }
            }, function (response) {
                debugger;
            });
        }

        function goToList() {
            $location.path('/students');
        }

        
    }

})(angular,_);
