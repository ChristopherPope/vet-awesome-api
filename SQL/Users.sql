select u.Id "UserId", u.Name, ur.Name "Role", ur.Id "RoleId" from users u
inner join UserRoles ur on u.UserRoleId = ur.Id
order by ur.Name