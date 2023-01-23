# StockVille

A gamified version of the stock market. 

Hosting AT NOT YET IMPLEMENTED

### Stack:
- React
- ASP.NET API
- Firebase
- React-Redux
- React-Router
- Firebase SDK 3 with OAuth authentication
- Azure Cosmos


#### Configure this app with your project-specific details:
```javascript
// .firebaserc

{
  "projects": {
    "default": "your-project-id"
  }
}
```
```javascript
// src/core/firebase/config.js

export const firebaseConfig = {
  apiKey: 'your api key',
  authDomain: 'your-project-id.firebaseapp.com',
  databaseURL: 'https://your-project-id.firebaseio.com',
  storageBucket: 'your-project-id.appspot.com'
};
```

#### Build and deploy the app:
```shell
$ npm run build
$ firebase login
$ firebase use default
$ firebase deploy
```
