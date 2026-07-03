import { check } from 'k6';
import http from 'k6/http';

export let options = {
    stages: [
        { duration: '10s', target: 20 }, // Ramp up to 10 users
        { duration: '40s', target: 20 },  // Maintain 10 users
        { duration: '10s', target: 0 },   // Scale down to 0
    ],
    thresholds: {
        http_req_duration: ['p(95)<500'], // 95% of requests must be < 500ms
    },
};

export default function () {
    const apiUrl = 'https://localhost:7280'

    let response = http.get(`${apiUrl}/api/cards/get-cards`);
    
    check(response, {
        'status was 200': (r) => r.status === 200,
    });
}