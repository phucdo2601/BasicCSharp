import { Box, Grid, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { StaffRoleResModel } from "./models/response/StaffRoles/staffRoles.res.dto";
import StaffRoleApi from "./apis/StaffRoles/StaffRoleApi";
import { DataGrid, GridColDef } from "@mui/x-data-grid";

const columns: GridColDef<StaffRoleResModel>[] = [
  {
    field: "id",
    headerName: "ID",
    width: 150,
  },
  {
    field: "staffRoleCode",
    headerName: "staffRoleCode",
    width: 150,
  },
  {
    field: "staffRoleTitle",
    headerName: "staffRoleTitle",
    width: 150,
  },
];

const App = () => {
  const [listStaffRoles, setListStaffRoles] = useState<StaffRoleResModel[]>([]);

  useEffect(() => {
    const getAllStaffRoles = () => {
      StaffRoleApi.getAllStaffRoles().then((res) => {
        console.log(res.data);
        setListStaffRoles(res.data);
      });
    };

    getAllStaffRoles();
  }, []);

  return (
    <>
      <div className="">
        <Typography variant="h1" gutterBottom>
          h1. Heading
        </Typography>

        <Box
          sx={{
            height: 400,
            width: "100%",
          }}
        >
          <DataGrid
            rows={listStaffRoles}
            columns={columns}
            initialState={{
              pagination: {
                paginationModel: {
                  pageSize: 5,
                },
              },
            }}
            pageSizeOptions={[5, 10, 15]}
            checkboxSelection
          />
        </Box>
      </div>
    </>
  );
};

export default App;
