export function getPureArrayFromTableRows(tableRows, tableColumns) {
    return tableRows.map(r => { 
        let row = {};
        for(let field of r) {
            for(let column of tableColumns) {
                if(field.name === column.name) {
                    row[column.name] = field.value;
                }
            }
        }
        return row;
    });
}

export function getPureArrayFromTableColumns(tableColumns) {
    return tableColumns.map(c => {
        let col = {};
        col[c.name] = c.title;
        return col;
    });
}

export function getTableColumnsObject(tableColumns) {
    let col = {};
    for(let column of tableColumns) {
        col[column.name] = column.title;
    }
    return col;
}

export function getObjectFromTableRow(row) {
    let obj = {};
    for(let field of row) {
        obj[field.name] = field.value;
    }
    return obj;
}