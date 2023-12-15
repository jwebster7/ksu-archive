import xlrd

wb = xlrd.open_workbook("dataset_DBPROJ.xls")
sh = wb.sheet_by_index(0)

filename = "datasetOutput.txt"
with open(filename, 'w') as f:
    for row in sh.get_rows():
        f.write("(" + ', '.join(map(lambda x: "N'" + x.value + "'" if isinstance(x.value, str) else str(x.value), row)) + '),\n')
       