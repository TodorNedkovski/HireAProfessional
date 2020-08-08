function apply(userId, companyId) {
    let headers = {
        method: 'POST',
        body: JSON.stringify({
            'userId': userId,
            'companyId': companyId
        }),
        headers: {
            'content-type': 'application/json'
        }
    }

    fetch('https://localhost:44319/api/applications', headers)
        .then(r => r.json())
        .then(r => {
            console.log(r)
        })
}