import { LoginCard } from "./shared/LoginCard";

export const Register = () => {
  return (
    <>
      <LoginCard
        header="Rekistöröidy"
        primaryButtonText="Rekisteröi käyttäjä"
        verifyPassword
        registerCheck="Minulla onkin olemassa oleva käyttäjä"
      />
    </>
  );
};
