import React, {useEffect, useState, useHistory} from "react";
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';

function Copyright(props) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit" href="https://github.com/rysonw">
        Ryson Wong
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const theme = createTheme({
  palette: {
    primary: {
      main: '#21295c',
    },
    secondary: {
      light: '#21295c',
      main: '#ffd166',
    },
  },
});

export default function LoginForm() {
  const handleSubmit = async(event) => {
    event.preventDefault();

    // const response = await axios.post('https://localhost:5000/api/login_data', {
    //   user: user,
    //   password: password
    // }, {
    //   headers: {
    //     'Content-Type': 'application/json'
    //   }
    // })
    // .then(function (response) {
    //   alert(response)
    // })
    // .catch(function (error) {
    //   alert(error);
    // });

    fetch('https://localhost:5000/api/login_data', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        user: user,
        password: password
      })
    })
      .then(response => response.json())
      .then(data => {
        alert(data)
      })
      .catch(error => {
        alert(error);
      });

  };



 
const [password, setPassword] = useState("");
const [user, setUser] = useState("");
  
const handleChangePassword = event => setPassword(event.target.value);
const handleChangeUser = event => setUser(event.target.value);

  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs" backgroundColor="#21295c">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            LOGIN
          </Typography>
          <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
            {/* Run whatever this is aganist both usernam and email column */}
            <TextField
              margin="normal"
              required
              fullWidth
              id="user"
              label="Username/Email Address"
              name="user"
              autoComplete="user"
              value={user}
              onChange={handleChangeUser}
              autoFocus
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              value={password}
              onChange={handleChangePassword}
              autoComplete="current-password"
            />

            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2, currentcolor: "#000000" }}
              onClick={handleSubmit}
            >
              LOGIN
            </Button>
            <Grid container>
              <Grid item>
                <Link href="/signup" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}
