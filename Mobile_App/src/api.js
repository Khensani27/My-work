// api.js
import axios from 'axios';

const API_URL = 'https://libraryapi-hxbwaxb4bdfkcvg9.southafricanorth-01.azurewebsites.net/api/'; // Your base API URL

const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Function to get user data by email and password
export const getUser = async (email, password) => {
  try {
    const response = await api.get(`User/getUser`, {
      params: {
        email: email,
        password: password,
      },
    });
    
    // If response is successful, return the user data
    if (response.status === 200) {
      return response.data; // Return the user object
    }

    // If user is not found, return null
    return null;
  } catch (error) {
    console.error('Fetch error:', error);
    throw error; // Rethrow error to be caught in handleLogin
  }
};

// Other API functions can go here...
