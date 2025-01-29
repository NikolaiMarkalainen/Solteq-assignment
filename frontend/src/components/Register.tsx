import { useLoginHook } from "../hooks/useLoginHook";
import { LoginCard } from "./shared/LoginCard";

export const Register = () => {
  const {
    handlePasswordChange,
    handleUserNameChange,
    handlePasswordVerification,
    onSubmit,
    errorMessage,
    handleInputFocus,
  } = useLoginHook();
  return (
    <>
      <LoginCard
        header="Rekistöröidy"
        primaryButtonText="Rekisteröi käyttäjä"
        verifyPassword
        registerCheck="Minulla onkin olemassa oleva käyttäjä"
        onChangeUsername={handleUserNameChange}
        onChangePassword={handlePasswordChange}
        onVerificationPassword={handlePasswordVerification}
        onSubmit={onSubmit}
        errorMessage={errorMessage}
        handleInputFocus={handleInputFocus}
      />
    </>
  );
};
