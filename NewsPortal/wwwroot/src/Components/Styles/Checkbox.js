import React from 'react'
import Checkbox from '@material-ui/core/Checkbox'

export default ({
    input: { checked, onChange, value, ...restInput },
    meta,
    ...rest
}) => (
        <Checkbox
            {...rest}
            inputProps={restInput}
            onChange={onChange}
            checked={Boolean(checked)}
            value={value}
        />
    )
