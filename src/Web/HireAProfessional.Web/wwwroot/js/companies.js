function getCompanies() {
    let headers = {
        method: 'GET',
        headers: {
            'content-type': 'application/json'
        }
    }

    fetch('https://localhost:44319/api/companies', headers)
        .then(r => r.json())
        .then(r => {
            console.log(r)
        })
}