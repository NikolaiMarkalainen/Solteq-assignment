import { defineConfig, loadEnv } from "vite";
import react from "@vitejs/plugin-react";

// https://vite.dev/config/
export default defineConfig(({ mode }) => {
  const env = loadEnv(mode, "");

  return {
    plugins: [react()],
    build: {
      outDir: "../backend/Solteq-server/wwwroot", // Ensure this points to the wwwroot folder in your .NET project
      emptyOutDir: true, // Clean the folder before building
    },
    server: {
      host: "0.0.0.0", // Listen on all interfaces
      allowedHosts: ["solteq-frontend", "solteq-dev-frontend"],
      proxy: {
        "/api": {
          target:
            env.VITE_API_TARGET === "PROD"
              ? "http://solteq-api:5151"
              : "http://solteq-dev-api:5151",
          changeOrigin: true,
          rewrite: (path) => path.replace(/^\/api/, ""),
        },
      },
    },
  };
});
