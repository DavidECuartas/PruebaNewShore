/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      colors: {
        primary: '#EEF5FF',
        secondary: '#B4D4FF',
        accent: '#86B6F6',
        dark: '#176B87',
      }
    },
  },
  plugins: [],
}

