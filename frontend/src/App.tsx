import { Navigate, Route, Routes } from "react-router-dom";
import { Login } from "./components/Login";
import { Register } from "./components/Register";
import { useCookies } from "react-cookie";
import { FrontPage } from "./components/FrontPage";

export const App = () => {
  const [cookie] = useCookies(["token"]);

  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      {!cookie.token && (
        <Route path="*" element={<Navigate to="/login" replace />} />
      )}
      <Route path="*" element={<Navigate to="/home" replace />} />
      {cookie.token && <Route path="/home" element={<FrontPage />} />}
    </Routes>
  );
};
