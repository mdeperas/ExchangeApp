import angular from 'angular';
import routing from './app.config';
import transition from './app.route.config';
import resource from 'angular-resource';
import { interceptors, authInterceptor } from './config/interceptor';
import { AppComponent, TopMenuComponent, LoginComponent, LoginFormComponent, RegisterComponent, RegisterFormComponent, HomeComponent } from './components';
import { AccountResource } from './resources/accountResource';
import { AuthService } from './services/authService';
import { TokenService } from './services/tokenService';
import { PrincipalService } from './services/principalService';
import { UserInfoService } from './services/userInfoService';
import { compareTo } from './components';

export default angular.module('app', ['ui.router', resource])
  .config(routing)
  .config(interceptors)
  .run(transition)
  .factory('AccountResource', AccountResource)
  .factory('authInterceptor', authInterceptor)
  .service('AuthService', AuthService)
  .service('TokenService', TokenService)
  .service('PrincipalService', PrincipalService)
  .service('UserInfoService', UserInfoService)
  .directive('compareTo', compareTo)
  .component('appComponent', AppComponent)
  .component('topMenuComponent', TopMenuComponent)
  .component('loginComponent', LoginComponent)
  .component('loginFormComponent', LoginFormComponent)
  .component('registerComponent', RegisterComponent)
  .component('registerFormComponent', RegisterFormComponent)
  .component('homeComponent', HomeComponent);
