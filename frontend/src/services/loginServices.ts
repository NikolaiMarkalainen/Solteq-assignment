import axios from "axios";

interface userBody {
  username: string;
  password: string;
}
const apiUrl = import.meta.env.VITE_API_URL;

export const registerUser = async (userBody: userBody) => {
  try {
    const response = await axios.post(`${apiUrl}/api/Auth/register`, userBody);
    return response.data;
  } catch (e) {
    console.log(e);
  }
};

export const logUserIn = async (userBody: userBody) => {
  try {
    const response = await axios.post(`${apiUrl}/api/Auth/login`, userBody);
    return response.data;
  } catch (e) {
    console.log(e);
  }
};
