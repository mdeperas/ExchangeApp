routing.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

export default function routing($stateProvider, $urlRouterProvider, $locationProvider) {

  $locationProvider.html5Mode(true);

    $urlRouterProvider.otherwise('/404');

    //app
    //dwa drzewka stanow
    //free (free.)
    //logged

    let notFoundState = {
      name: '404',
      url: '/404',
      template: '<h1>404</h1>'
    };

    let freeState = {
      name: 'free',
      abstract: 'true'
    }

    let restrictedState = {
      name: 'restricted',
      abstract: 'true'
    }

    let restrictedHomeState = {
      name: 'free.home',
      url: '/',
      component: 'homeComponent',
      resolve: {
        currencies: function(Currencies) {
          return Currencies.query();
        }
      }
    }

    let aboutState = {
      name: 'free.about',
      url: '/about',
      template: require('./components/about/about.component.html')
    };

    let loginState = {
      name: 'free.login',
      url: '/login',
      component: 'loginComponent'
    };

    let registerState = {
      name: 'free.register',
      url: '/register',
      component: 'registerComponent'
    };

    $stateProvider.state(freeState);
    $stateProvider.state(restrictedState);
    $stateProvider.state(restrictedHomeState);
    $stateProvider.state(aboutState);
    $stateProvider.state(loginState);
    $stateProvider.state(notFoundState);
    $stateProvider.state(registerState);
};