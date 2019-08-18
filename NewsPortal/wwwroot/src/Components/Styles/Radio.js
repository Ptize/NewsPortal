import React from 'react'
import Radio from '@material-ui/core/Radio'

export default ({
    input: { checked, onChange, value, ...restInput },
    meta,
    ...rest
}) => (
        <Radio
            {...rest}
            inputProps={restInput}
            onChange={onChange}
            checked={Boolean(checked)}
            value={value}
        />
    )
