
(function () {
    'use strict';

    angular
       .module('studentApp.student.controllers')
       .controller('StudentListController', ['$route', '$location', 'StudentProvider', StudentListController]);

    function StudentListController($route, $location, Student) {
        var vm = this;
        vm.students = [];
        vm.searchValue = '';
        vm.totalItems = 0;
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.pageChanged = pageChanged;
        vm.pageSizeChanged = pageSizeChanged;

        vm.addStudent = addStudent;
        vm.filterRecords = filterRecords;

        load();

        //////////////////////////////////////////////////////////////////////

        function load() {
            vm.students = $route.current.locals.students.data.list;
            vm.totalItems = $route.current.locals.students.data.count;

            vm.pageSize = $route.current.params.pageSize || 10;
            vm.pageSize = vm.pageSize + '';
            vm.currentPage = $route.current.params.page || 1;
            vm.searchValue = $route.current.params.searchValue || '';
        }

        function filterRecords() {
            goTo(vm.currentPage, vm.pageSize);
        }

        function addStudent() {
            $location.path('/student/create');
        }

        function goTo(page, pageSize) {
            $location.path('/students/' + page + '/' + pageSize + '/' + vm.searchValue);

        }

        function pageChanged() {
            goTo(vm.currentPage, vm.pageSize);
        }

        function pageSizeChanged() {
            vm.currentPage = 1;
            goTo(vm.currentPage, vm.pageSize);
        }
    }


})();
