import { APIURL } from "../config/api.config";

export class UserInfoService {
    constructor($http) {
        this.http = $http;
    }
    
    getUserInfo() {
        return this.http.get(APIURL + 'api/account');
    }
}