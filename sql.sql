SELECT * FROM htrans;

SELECT users.US_USERNAME AS 'Username ' , 
users.US_NAME AS 'Name', 
users.US_SALDO AS 'Saldo'
FROM users 
ORDER BY 1;


SELECT SP_ID AS 'ID ' , 
SP_NAME AS 'Nama', 
Brand.BR_NAME AS 'Brand', 

                
SELECT htrans.HT_ID AS 'ID' , 
htrans.HT_INVOICE_NUMBER AS 'Invoice',
htrans.HT_DATE AS 'Date',
users.us_name AS 'User',
htrans.HT_TOTAL AS 'Total',
CASE WHEN htrans.HT_STATUS =0 THEN 'Belum Kembali' 
WHEN htrans.HT_STATUS =1 'sudah kembali' 
WHEN htrans.HT_STATUS =2 'diacc dan ada denda'
ELSE ' tidak ada denda / sudah bayar denda' AS 'status'
FROM htrans,users 
WHERE htrans.HT_ID = users.US_ID ";
                
     