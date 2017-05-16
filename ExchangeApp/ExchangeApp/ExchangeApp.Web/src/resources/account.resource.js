export function AccountResource ($resource) {
    return $resource('http://localhost:59038/api/account', {}, {
        'get': {
            method: 'GET'
        }
    });
}