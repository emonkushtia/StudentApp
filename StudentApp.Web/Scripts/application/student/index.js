


(function (ng) {
    'use strict';

    ng.module('studentApp.student', [
        'ngRoute',
        'studentApp.student.controllers',
        'studentApp.student.models'
    ]).config([
            '$routeProvider',
            function ($routes) {
                $routes.when('/student/create', {
                    templateUrl: 'template/student/create.html',
                    controller: 'StudentCreateController',
                    controllerAs: 'StudentCreate',
                    resolve: {
                        courses: [
                            'StudentProvider',
                            function (StudentProvider) {
                                return StudentProvider.courses();
                            }
                        ]
                    }
                });

                $routes.when('/student/:id', {
                    templateUrl: 'template/student/view.html',
                    controller: 'StudentViewController',
                    controllerAs: 'StudentView',
                    resolve: {
                        student: [
                            '$route',
                            'StudentProvider',
                            function ($route, Student) {
                                return Student.one($route.current.params.id);
                            }
                        ]
                    }
                });

                $routes.when('/student/edit/:id', {
                    templateUrl: 'template/student/editstudent.html',
                    controller: 'StudentEditController',
                    controllerAs: 'StudentEdit',
                    resolve: {
                        student: [
                            '$route',
                            'StudentProvider',
                            function ($route, StudentProvider) {
                                return StudentProvider.one($route.current.params.id);
                            }
                        ],
                        courses: [
                            'StudentProvider',
                            function (StudentProvider) {
                                return StudentProvider.courses();
                            }
                        ]
                    }
                });
            }
        ]);

})(angular);