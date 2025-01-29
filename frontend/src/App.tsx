import { Navigate, Route, Routes } from "react-router-dom";
import { Login } from "./components/Login";
import { Register } from "./components/Register";

export const App = () => {
  // const getDataFromServer = async () => {
  //   const result = await fetch("http://localhost:5151/api/Products");
  //   console.log(result.json());
  // };
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />

      <Route path="*" element={<Navigate to="/login" replace />} />
    </Routes>
  );
};
