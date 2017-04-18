

(function (_, ng) {
    'use strict';

    function StudentProvider() {
        var url = 'api/students';

        this.$get = ['$http', function ($http) {
                return {
                    all: function (page, pageSize, searchValue) {
                        var offset = (page - 1) * pageSize;
                        return $http.get(url, {
                            params: {
                                offset: offset,
                                limit: pageSize,
                                searchValue: searchValue
                            }
                        });
                    },
                    create: function (student) {
                        return $http.post(url, student);
                    },
                    update: function(student) {
                        return $http.post(url + '/update', student);
                    },
                    one: function (id) {
                        return $http.get(url + '/' + id);
                    },
                    remove: function (id) {
                        return $http.delete(url + '/' + id);
                    },
                    courses: function () {
                        return $http.get('api/courses');
                    }

                };
            }
        ];
    }

    ng.module('studentApp.student.models').provider('StudentProvider', [StudentProvider]);

})(_, angular);