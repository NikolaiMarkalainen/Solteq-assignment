import axios from "axios";

interface userBody {
  username: string;
  password: string;
}

export const registerUser = async (userBody: userBody) => {
  try {
    const response = await axios.post(
      "http://localhost:5151/api/Auth/register",
      userBody,
    );
    return response.data;
  } catch (e) {
    console.log(e);
  }
};

export const logUserIn = async (userBody: userBody) => {
  try {
    const response = await axios.post(
      "http://localhost:5151/api/Auth/login",
      userBody,
    );
    return response.data;
  } catch (e) {
    console.log(e);
  }
};
