
(function (ng) {
    'use strict';

    ng.module('studentApp.student.controllers')
       .controller('StudentViewController', ['$route', '$location', 'StudentProvider', StudentViewController]);

    function StudentViewController($route, Location, Student) {

        var vm = this;
        vm.deleteStudent = deleteStudent;

        load();

        ////////////////////////////////////////////////////////////////////////////////

        function load() {
            vm.student = $route.current.locals.student.data;
        }


        function deleteStudent(id) {
            Student.remove(id).then(function () {
                alert('Student Successfully Delete');
                Location.path('/student');
            }, function (response) {
            });
        }
    }


})(angular);
