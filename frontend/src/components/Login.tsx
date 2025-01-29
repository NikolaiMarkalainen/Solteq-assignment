import { LoginCard } from "./shared/LoginCard";
import { useLoginHook } from "../hooks/useLoginHook";

export const Login = () => {
  const {
    handlePasswordChange,
    handleUserNameChange,
    onSubmit,
    errorMessage,
    handleInputFocus,
  } = useLoginHook();

  return (
    <>
      <button onClick={() => console.log("asd")}></button>
      <LoginCard
        header="Kirjaudu sisään"
        primaryButtonText="Kirjaudu sisään"
        registerCheck="Eikö ole vielä käyttäjää? Rekisteröidy täältä."
        onChangeUsername={handleUserNameChange}
        onChangePassword={handlePasswordChange}
        onSubmit={onSubmit}
        errorMessage={errorMessage}
        handleInputFocus={handleInputFocus}
      />
    </>
  );
};
