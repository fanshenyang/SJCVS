<?php

namespace dao;

use Exception;

class DbConnecter
{
    //connect db and get result
    //statement是语句,$database是数据库名
    public function cag($statement, $database)
    {
        try {
            $conarr = include "/SJYYT/Controller/dao/DbConfig.php";
            $conn = mysqli_connect($conarr['host'], $conarr['username'], $conarr['password']);
            mysqli_select_db($conn, $database);
            $result = mysqli_query($conn, $statement);
            return $result;
        } catch (Exception $ex) {
            return [];
        }
    }
    public function test()
    {
        echo '1';
    }
}
