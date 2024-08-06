import { basicCalApi } from "../baseUrl"

const getAllStaffRoles = async () => {
    return await basicCalApi().get(`StaffRole/getAllStaffRoles`);
}

const StaffRoleApi = {
    getAllStaffRoles
};

export default StaffRoleApi;