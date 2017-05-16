import { APIURL } from "../config/api.config";

export function Currencies($resource) {
    return $resource(APIURL + '/api/currencies', {}, {
        'query': { method: 'GET', isArray: true }
    });
}