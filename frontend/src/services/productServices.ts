import axios from "axios";

const apiUrl = import.meta.env.VITE_API_URL;

export const getProducts = async (cookie: string) => {
  try {
    const response = await axios.get(`${apiUrl}/api/Products/generics`, {
      headers: {
        Authorization: `Bearer ${cookie}`,
      },
    });
    return response.data;
  } catch (e) {
    console.log(e);
  }
};

export const getFilteredProducts = async (cookie: string, query: string) => {
  try {
    const response = await axios.get(
      `${apiUrl}/api/Products/generics/${query}`,
      {
        headers: {
          Authorization: `Bearer ${cookie}`,
        },
      },
    );
    return response.data;
  } catch (e) {
    console.log(e);
  }
};

export const getSingleProductDetails = async (
  cookie: string,
  query: string,
) => {
  try {
    const response = await axios.get(`${apiUrl}/api/products/${query}`, {
      headers: {
        Authorization: `Bearer ${cookie}`,
      },
    });
    return response.data;
  } catch (e) {
    console.log(e);
  }
};
