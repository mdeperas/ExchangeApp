export class AuthService {
    constructor($http, PrincipalService, $state, $q) {
        this.http = $http;
        this.state = $state;
        this.q = $q;
        this.PrincipalService = PrincipalService;
    }

    login(username, password) {
        let data = 'grant_type=password&client_secret=client_secret&client_id=client_id&username=' + encodeURIComponent(username) + '&password=' + encodeURIComponent(password);
        
        let deffered = this.q.defer();
        this.http.post('http://localhost:60419/token', data, { 
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
            "Accept": "application/json"
        }}).then(
            (response) => {
                let token = response.data || response;
                this.PrincipalService.authenticate(token);
                deffered.resolve(token);
            },
            (errorResponse) => {
                deffered.reject(errorResponse);
            }
        );

        return deffered.promise;
    }

    register(user) {
        return this.http.post('http://localhost:60419/api/account/register', user, {
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }});
    }
}