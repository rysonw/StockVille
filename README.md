# StockVille

A gamified version of the stock market. 

Hosted @ NOT YET IMPLEMENTED

Stack
React
ASP.NET API
Firebase
React-Redux
React-Router
Firebase SDK 3 with OAuth authentication
Azure Cosmos

Install firebase-tools:
$ npm install -g firebase-tools
Build and deploy the app:
$ npm run build
$ firebase login
$ firebase use default
$ firebase deploy

// .firebaserc

{
  "projects": {
    "default": "your-project-id"
  }
}
// src/core/firebase/config.js

export const firebaseConfig = {
  apiKey: 'your api key',
  authDomain: 'your-project-id.firebaseapp.com',
  databaseURL: 'https://your-project-id.firebaseio.com',
  storageBucket: 'your-project-id.appspot.com'
};
