


(function (ng) {
    ng.module('studentApp', [
            'ngRoute',
            'ngAnimate',
            'studentApp.student'
    ]).config([
            '$routeProvider', function ($routeProvider) {
                $routeProvider.when('/students/:page?/:pageSize?/:searchValue?', {
                    templateUrl: 'template/student/studentList.html',
                    controller: 'StudentListController',
                    controllerAs: 'StudentList',
                    resolve: {
                        students: [
                            'StudentProvider',
                            '$route',
                            function (Student, $route) {
                                var params = $route.current.params;
                                params.page = params.page || 1;
                                params.pageSize = params.pageSize || 10;
                                params.searchValue = params.searchValue || '';
                                return Student.all(params.page, params.pageSize, params.searchValue);
                            }
                        ]
                    }
                });

                $routeProvider.otherwise('/students');
            }
        ]);
})(angular);