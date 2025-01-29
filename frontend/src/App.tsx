import { Navigate, Route, Routes } from "react-router-dom";
import { Login } from "./components/Login";
import { Register } from "./components/Register";
import { useCookies } from "react-cookie";
import { FrontPage } from "./components/FrontPage";

export const App = () => {
  const [cookie] = useCookies(["token"]);

  // const getDataFromServer = async () => {
  //   const result = await fetch("http://localhost:5151/api/Products");
  //   console.log(result.json());
  // };
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      {!cookie.token && (
        <Route path="*" element={<Navigate to="/login" replace />} />
      )}
      <Route path="*" element={<Navigate to="/home" replace />} />

      <Route path="/home" element={<FrontPage />} />
    </Routes>
  );
};
