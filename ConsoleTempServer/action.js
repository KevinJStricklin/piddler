angular.module('todoApp', ['ngResource'])
    .factory('test', function ($resource) {
        return $resource('/temperature', {}, {
            query: { method: 'GET', params: {}, isArray: false }
        });
    })
    .controller('TodoController', ['$scope', 'test', function ($scope, test) {
        $scope.todos = [
            { text: 'learn angular', done: true },
            { text: 'build an angular app', done: false }
        ];

        $scope.temperature = 37;

        test.query(function (response) {
            $scope.temperature = response;
        });

        test.get({}, function (resp) {
            $scope.rtemperature = resp.temperature;
        });

        $scope.addTodo = function () {
            $scope.todos.push({ text: $scope.todoText, done: false });
            $scope.todoText = '';
        };
    }]);
