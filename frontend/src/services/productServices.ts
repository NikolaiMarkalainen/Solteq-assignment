import axios from "axios";

export const getProducts = async (cookie: string) => {
  try {
    const response = await axios.get(
      "http://localhost:5151/api/Products/generics",
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
