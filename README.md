# Spike-Cards

This is a spike project that contains an application to learn new technology, processes, carry out experiments and just mess about with.

# Current Status

- [x] MVC API.
- [x] Singleton based Cards Collection Repository.

## Currently Working On

- [ ] Implementing Minimal API.
- [ ] CLI App needs re-adjusting and adding into solution.
- [ ] Implementing DB
- [ ] Implementing Docker
- [ ] Implementing DB Test Containers
- [ ] Implement Infra as Code using Pulumi to AWS / Azure

## API Endpoints

Needs readjusting for more REST like end points.

- GET => `/api/cards/get-cards`
- GET => `/api/cards/serach/by-name/{name}`
- GET => `/api/cards/serach/by-cost/{cost:int}`
- GET => `/api/cards/serach/by-health/{health:int}`
- GET => `/api/cards/serach/by-attack/{attack:int}`
- GET => `/api/cards/serach/by-description/{description}`