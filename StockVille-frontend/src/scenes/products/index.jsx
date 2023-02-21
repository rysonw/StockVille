import React, { useState } from "react";
import {
  Box,
  Card,
  CardActions,
  Collapse,
  Button,
  useTheme,
  useMediaQuery,
} from "@mui/material";
import Header from "components/Header";
//import { useGetProductsQuery } from "state/api";

const Stock = ({
  _id,
  symbol,
  company,
  currPrice,
  priceChange
}) => {
  const theme = useTheme();
  const [isExpanded, setIsExpanded] = useState(false);

  return ( //REM is more consistent over browsers vs px
    <Card
      sx={{
        backgroundImage: "none",
        backgroundColor: theme.palette.background.alt,
        borderRadius: "0.55rem",
      }}
    >

      <CardActions>
        <Button
          variant="primary"
          size="small"
          onClick={() => setIsExpanded(!isExpanded)}
        >
          See More
        </Button>
      </CardActions>
      <Collapse
        in={isExpanded}
        timeout="auto"
        unmountOnExit
        sx={{
          color: theme.palette.neutral[300],
        }}
      >

      </Collapse>
    </Card>
  );
};

function useGetStocksQuery(symbol) {
  const handleSubmit = async(event) => {
    event.preventDefault();

    fetch('https://localhost:5000/api/stock', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ //search stock table based on symbol
        symbol: symbol
      })
    })
      .then(response => response.json())
      .then(data => {
        alert(data)
      })
      .catch(error => {
        alert(error);
      });

  }
};

const Stocks = () => {
  const { data, isLoading } = useGetStocksQuery();
  const isNonMobile = useMediaQuery("(min-width: 1000px)");

  return (
    <Box m="1.5rem 2.5rem">
      <Header title="STOCKS" subtitle="Current List of Stocks" />
      {data || !isLoading ? (
        <Box
          mt="20px"
          display="grid"
          gridTemplateColumns="repeat(4, minmax(0, 1fr))"
          justifyContent="space-between"
          rowGap="20px"
          columnGap="1.33%"
          sx={{
            "& > div": { gridColumn: isNonMobile ? undefined : "span 4" },
          }}
        >
          {data.map(
            ({
              _id,
              name,
              description,
              price,
              rating,
              category,
              supply,
              stat,
            }) => (
              <Stock
                // key={_id}
                // _id={_id}
                // name={name}
                // description={description}
                // price={price}
                // rating={rating}
                // category={category}
                // supply={supply}
                // stat={stat}
              />
            )
          )}
        </Box>
      ) : (
        <>Loading...</>
      )}
    </Box>
  );
};

export default Stocks;
