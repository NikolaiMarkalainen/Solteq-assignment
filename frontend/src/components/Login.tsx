import { LoginCard } from "./shared/LoginCard";

export const Login = () => {
  return (
    <>
      <LoginCard
        header="Kirjaudu sisään"
        primaryButtonText="Kirjaudu sisään"
        registerCheck="Eikö ole vielä käyttäjää? Rekisteröidy täältä."
      />
      ;
    </>
  );
};
